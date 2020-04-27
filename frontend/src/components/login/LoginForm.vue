<template>
  <form class="form">
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
    <section class="form-input create-user">
      <label>Har du ikke bruker?</label>
      <router-link :to="{ name: 'CreateUser'}">Lag bruker</router-link>
    </section>

    <section class="feedback" @change="showError">
      <p>{{errorMsg}}</p>
    </section>
  </form>
</template>

<script>
import { store } from "../../store.js";

import axios from "axios";

export default {
  name: "LoginForm",
  data() {
    return {
      email: "",
      password: "",
      errorMsg: undefined
    };
  },
  methods: {
    showError() {
      let form = document.querySelector(".content");
      let errorDiv = document.querySelector(".feedback");
      form.classList.add("error");
      errorDiv.classList.add("error");
      setTimeout(() => {
        form.classList.remove("error");
        errorDiv.classList.remove("error");
      }, 7000);
    },
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
              console.log(true);
              store.state.loggedIn = true;
              store.state.isAdmin = response.data.admin;
              store.state.user = {
                email: response.data.email,
                firstName: response.data.firstName,
                lastName: response.data.lastName
              };
              this.$router.push({ name: "Homepage" });
            } else {
              this.errorMsg = "Feil brukernavn eller passord";
              this.showError();
            }
          } else if (response.status == 204) {
            this.errorMsg = "Bruker finnes ikke";
            this.showError();
          }
        })
        .catch(error => {
          if (error.response.status == 404) {
            this.errorMsg = "Ingen brukernavn funnet";
            this.showError();
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

.feedback {
  position: absolute;
  bottom: 0px;
  left: 0;
  width: 100%;
  background: rgb(180, 0, 0);
  color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  transition: 0.3s ease-in-out;
  height: 50px;
  padding: 10px;
  z-index: -2;
}

.feedback.error {
  bottom: -70px;
}
</style>