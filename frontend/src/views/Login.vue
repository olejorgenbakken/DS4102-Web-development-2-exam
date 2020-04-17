<template>
  <section class="login">
    <TheHeader class="padding"></TheHeader>
    <section class="wrapper">
      <section class="content">
        <header class="login-header">
          <h2>Login</h2>
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
          <button class="create-user">Lag bruker</button>
        </form>
        <section class="feedback"></section>
      </section>
    </section>
    <TheFooter></TheFooter>
  </section>
</template>

<script>
import axios from "axios";
import TheHeader from "../components/TheHeader.vue";
import TheFooter from "../components/TheFooter.vue";
export default {
  name: "Login",
  components: {
    TheHeader,
    TheFooter
  },
  data() {
    return {
      name: "",
      pass: ""
    };
  },
  created() {
    if (sessionStorage.getItem("user") != null) {
      let id = JSON.parse(sessionStorage.getItem("user")).id;
      this.$router.push({
        name: "Admin",
        params: { id }
      });
    }
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
              let user = {
                id: response.data.id,
                username: response.data.username,
                firstName: response.data.firstName
              };
              sessionStorage.setItem("user", JSON.stringify(user));
              this.$router.push({
                name: "Admin",
                params: { id }
              });
            }
          }
        })
        .catch(error => {
          if (error.response.status == 404) {
            let form = document.querySelector(".content");
            let errorDiv = document.querySelector(".feedback");
            form.classList.add("error");
            errorDiv.classList.add("error");
            errorDiv.innerHTML = "<p>User not found</p>";
            setTimeout(() => {
              form.classList.remove("error");
              errorDiv.classList.remove("error");
            }, 7000);
          }
        });
    }
  }
};
</script>

<style scoped>
.login {
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 70px calc(100vh - 70px) auto;
  width: 100%;
}

.wrapper {
  background: url("https://images.unsplash.com/photo-1586982469023-9f3e18321fc7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1955&q=80");
  background-size: cover;
  background-position: center center;
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.content {
  width: 80%;
  max-width: 400px;
  border-radius: 3px;
  background: white;
  padding: 20px 20px 25px 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
  display: grid;
  grid-template-columns: 1fr;
  gap: 10px;
  position: relative;
  overflow: hidden;
}

.content.error {
  padding: 20px 20px 45px 20px;
}

.login-header {
  text-align: center;
  font-size: 0.8em;
}

form {
  display: grid;
  grid-template-columns: 1fr;
  gap: 10px;
}

form section {
  display: flex;
  flex-direction: column;
}

form input {
  border: 2px solid var(--color);
  border-radius: 2px;
  padding: 5px;
  font-family: var(--paragraph);
}

form label {
  padding: 0 0 2px 3px;
}

form button {
  background: var(--color);
  padding: 9px;
  color: white;
  font-family: var(--heading);
  font-weight: 700;
  font-size: 0.9em;
  border-radius: 5px;
}

.feedback {
  background: rgb(221, 46, 46);
  color: white;
  font-size: 0.9em;
  height: 0px;
  overflow: hidden;
  display: flex;
  justify-content: center;
  align-items: center;
  position: absolute;
  bottom: 0;
  left: 0;
  width: 100%;
}

.content,
.feedback {
  transition: 0.2s ease-in-out;
}

.feedback.error {
  height: 30px;
}

.create-user {
  background: transparent;
  color: var(--color);
  padding: 0;
}

@media only screen and (min-width: 800px) {
  .login {
    grid-template-rows: 100px calc(100vh - 100px) auto;
  }

  .wrapper {
    padding-bottom: 50px;
  }
}
</style>