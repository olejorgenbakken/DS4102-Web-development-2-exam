<template>
  <section class="container">
    <header>
      <h1>Login</h1>
    </header>
    <section class="inputs">
      <input type="text" v-model="name" />
      <input type="password" v-model="pass" />
      <button @click="login">Logg inn</button>
    </section>
  </section>
</template>

<script>
import axios from "axios";
export default {
  name: "Login",
  data() {
    return {
      name: "",
      pass: "",
      user: {
        username: this.name,
        password: this.pass
      }
    };
  },
  methods: {
    login() {
      let userDB = "https://localhost:5001/api/users";
      axios.get(userDB).then(response => {
        console.log(response.data);
        console.log(this.user);
        if (
          response.data.username === this.user.username &&
          response.data.password === this.user.password
        ) {
          console.log("login successfull");
        } else if (
          response.data.username === this.user.username &&
          response.data.password != this.user.password
        ) {
          console.log("wrong password");
        } else {
          console.log("no user with that username");
        }
      });
    }
  }
};
</script>

<style scoped>
.container {
  height: 100vh;
  width: 100vw;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

header {
  height: 100px;
}
</style>