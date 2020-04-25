<template>
  <form class="card shadow form">
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
    <section class="form-input create-user">
      <label>Har du allerede bruker?</label>
      <router-link :to="{ name: 'Login'}">Logg inn</router-link>
    </section>

    <section class="feedback" @change="showError">
      <p>{{errorMsg}}</p>
    </section>
  </form>
</template>

<script>
import { store } from "../../store";
import axios from "axios";

export default {
  name: "CreateUser",
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
      let userDb = `https://localhost:5001/users/`;
      let userDbCheck = `https://localhost:5001/users/${this.email}`;
      axios.get(userDbCheck).then(response => {
        if (response.status == 200) {
          this.errorMsg =
            "En bruker med dette brukernavnet eksisterer allerede";
          this.showError();
        } else if (
          !this.email ||
          !this.password ||
          !this.firstname ||
          !this.lastname
        ) {
          this.errorMsg = "Vennligst fyll ut alle feltene";
          this.showError();
        } else if (response.status == 204 && this.password.length < 8) {
          this.errorMsg = "Vennligst velg et lengre passord";
          this.showError();
        } else if (response.status == 204 && this.password.length > 8) {
          let newUser = {
            email: this.email,
            password: this.password,
            firstname: this.firstname,
            lastname: this.lastname
          };
          axios.post(userDb, newUser).then(() => {
            store.state.loggedIn = true;
            store.state.user = newUser;
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
  transition: 0.1s ease-in-out;
  height: 50px;
  padding: 10px;
  z-index: -2;
}

.feedback.error {
  bottom: -50px;
}
</style>