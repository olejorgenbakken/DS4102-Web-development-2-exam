<template>
  <form class="card login-form">
    <section class="form-input">
      <label>Username</label>
      <input type="text" v-model="name" />
    </section>
    <section class="form-input">
      <label>Password</label>
      <input type="password" v-model="pass" />
    </section>

    <button class="login-button" @click="login">Logg inn</button>
    <button class="create-user">Lag bruker</button>
    <section class="feedback" @change="showError">
      <p>{{errorMsg}}</p>
    </section>
  </form>
</template>

<script>
import axios from "axios";

export default {
  name: "LoginForm",
  data() {
    return {
      name: "",
      pass: "",
      id: undefined,
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
      let adminDb = `https://localhost:5001/users/user/${this.name}`;
      axios
        .get(adminDb)
        .then(response => {
          if (response.status == 200) {
            if (
              response.data.username == this.name &&
              response.data.password == this.pass &&
              response.data.admin
            ) {
              let name = "login";
              let expires;
              let date = new Date();
              date.setTime(date.getTime() + 1 * 24 * 60 * 60 * 1000);
              expires = "; expires=" + date.toGMTString();
              document.cookie = name + "=" + response.data.id + expires;
              this.$router.push(`admin`);
            } else if (
              response.data.username == this.name &&
              response.data.password == this.pass &&
              !response.data.admin
            ) {
              console.log("bye");
            } else {
              this.showError();
              this.errorMsg = "Feil brukernavn eller passord";
            }
          } else if (response.status == 204) {
            this.showError();
            this.errorMsg = "Bruker finnes ikke";
          }
        })
        .catch(error => {
          if (error.response.status == 404) {
            this.showError();
            this.errorMsg = "Ingen brukernavn funnet";
          }
        });
    }
  }
};
</script>

<style scoped>
.login-form {
  padding: 20px;
  width: 80%;
  max-width: 350px;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
}

.form-input {
  margin-bottom: 15px;
}

.login-button {
  background: black;
  color: white;
}

.create-user {
  margin-top: 10px;
  font-weight: 700;
}
</style>