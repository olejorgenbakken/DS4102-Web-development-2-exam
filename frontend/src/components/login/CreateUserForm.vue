<template>
  <form class="form">
    <header>
      <h2>Lag ny bruker</h2>
    </header>
    <section class="form-input">
      <label>E-post</label>
      <input autocomplete="email" name="username" type="text" v-model="email" />
    </section>
    <section class="form-input">
      <label>Passord</label>
      <input autocomplete="new-password" name="password" type="password" v-model="password" />
      <label class="hint">Minst åtte tegn</label>
    </section>

    <section class="form-input">
      <label>Fornavn</label>
      <input autocomplete="given-name" name="first-name" type="text" v-model="firstname" />
    </section>
    <section class="form-input">
      <label>Etternavn</label>
      <input autocomplete="family-name" name="last-name" type="text" v-model="lastname" />
    </section>

    <section class="form-input">
      <button class="submit-btn" @click="login">Lag bruker</button>
    </section>

    <LoginFeedback :msg="errorMsg"></LoginFeedback>
  </form>
</template>

<script>
import axios from "axios";

import LoginFeedback from "./LoginFeedback";

export default {
  name: "CreateUser",
  components: {
    LoginFeedback
  },
  data() {
    return {
      email: null,
      password: null,
      firstname: null,
      lastname: null,
      errorMsg: undefined
    };
  },
  methods: {
    login(e) {
      e.preventDefault();
      let userDb = `https://localhost:5001/users/`;
      let userDbCheck = `https://localhost:5001/users/${this.email}`;
      axios.get(userDbCheck).then(response => {
        if (response.status == 200) {
          this.errorMsg =
            "En bruker med dette brukernavnet eksisterer allerede";
        } else if (
          !this.email ||
          !this.password ||
          !this.firstname ||
          !this.lastname
        ) {
          this.errorMsg = "Vennligst fyll ut alle feltene";
        } else if (response.status == 204 && this.password.length < 8) {
          this.errorMsg = "Vennligst velg et lengre passord";
        } else if (response.status == 204 && this.password.length > 8) {
          let newUser = {
            email: this.email,
            password: this.password,
            firstname: this.firstname,
            lastname: this.lastname
          };
          axios.post(userDb, newUser).then(() => {
            let name = "login";
            let expires;
            let date = new Date();
            date.setTime(date.getTime() + 1 * 24 * 60 * 60 * 1000);
            expires = "; expires=" + date.toGMTString();
            document.cookie = name + "=" + response.data.id + expires;
            this.$router.push({ name: "Homepage" });
          });
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
  position: relative;
  padding: 20px;
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