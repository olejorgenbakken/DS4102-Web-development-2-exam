<template>
  <section class="container">
    <header>
      <h1>Login</h1>
    </header>
    <form>
      <section>
        <label>Username</label>
        <input type="text" v-model="name" />
      </section>
      <section>
        <label>Password</label>
        <input type="password" v-model="pass" />
      </section>

      <button @click="login">Logg inn</button>
    </form>
    <section class="feedback"></section>
  </section>
</template>

<script>
import axios from "axios";
export default {
  name: "Login",
  data() {
    return {
      name: "",
      pass: ""
    };
  },
  methods: {
    login(e) {
      e.preventDefault();
      let user = { username: this.name, password: this.pass };
      let userDB = "https://localhost:5001/api/users/username/" + user.username;
      axios
        .get(userDB)
        .then(response => {
          if (response.status == 200) {
            if (
              response.data.username == user.username &&
              response.data.password == user.password
            ) {
              let id = response.data.id;
              sessionStorage.setItem("user", JSON.stringify(response.data));
              this.$router.push({
                name: "admin",
                params: { id }
              });
            }
          }
        })
        .catch(error => {
          if (error.response.status == 404) {
            console.log("User not found");
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
  padding: 0;
  padding-bottom: 200px;
  font-family: var(--paragraph);
}

header {
  height: 70px;
}

form {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
  width: 100%;
  max-width: 400px;
}

section {
  display: flex;
  flex-direction: column;
}

label {
  margin-left: 4px;
}

input {
  margin-top: 2px;
  border: 1px solid black;
  padding: 7px 6px;
  border-radius: 3px;
  font-size: 0.9em;
}

button {
  background: black;
  color: white;
  font-size: 1em;
  height: 30px;
  border-radius: 20px;
}
</style>