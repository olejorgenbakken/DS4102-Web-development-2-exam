<template>
  <form class="form">
    <header>
      <h2>Logg inn</h2>
    </header>
    <section class="form-input">
      <label>E-post</label>
      <input autocomplete="email" type="text" v-model="email" />
    </section>
    <section class="form-input">
      <label>Passord</label>
      <input autocomplete="password" type="password" v-model="password" />
    </section>

    <section class="form-input">
      <button class="submit-btn" @click="login">Logg inn</button>
    </section>

    <LoginFeedback :msg="errorMsg"></LoginFeedback>
  </form>
</template>

<script>
import axios from "axios";

import LoginFeedback from "./LoginFeedback";

export default {
  name: "LoginForm",
  components: {
    LoginFeedback
  },
  data() {
    return {
      email: "",
      password: "",
      errorMsg: undefined
    };
  },
  methods: {
    login(e) {
      e.preventDefault();

      let adminDb = `https://localhost:5001/users/${this.email}`;
      axios
        .get(adminDb)
        .then(response => {
          if (response.status == 200) {
            if (
              response.data.email == this.email &&
              response.data.password == this.password
            ) {
              let name = "login";
              let expires;
              let date = new Date();
              date.setTime(date.getTime() + 1 * 24 * 60 * 60 * 1000);
              expires = "; expires=" + date.toGMTString();
              document.cookie = name + "=" + response.data.id + expires;
              this.$router.push({ name: "Homepage" });
            } else {
              this.errorMsg = "Feil brukernavn eller passord";
            }
          } else if (response.status == 204) {
            this.errorMsg = "Bruker finnes ikke";
          }
        })
        .catch(error => {
          if (error.response.status == 404) {
            this.errorMsg = "Ingen brukernavn funnet";
          }
        });
    }
  }
};
</script>

<style scoped>
.form {
  width: 100%;
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
  padding: 20px;
  position: relative;
  background: var(--card-background);
}

.form-input {
  width: 100%;
  display: flex;
  flex-direction: column;
}

.create-user a {
  display: flex;
  flex-direction: row;
  font-weight: 700;
}

.create-user a::after {
  content: ">";
  margin-left: 5px;
}
</style>