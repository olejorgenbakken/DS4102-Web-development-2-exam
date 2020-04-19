<template>
  <section class="login">
    <TheHeader class="padding"></TheHeader>
    <section class="wrapper">
      <section class="content card">
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
        <section class="feedback" @change="showError">
          <p>{{errorMsg}}</p>
        </section>
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
      pass: "",
      id: undefined,
      errorMsg: undefined
    };
  },
  beforeMount() {
    if (document.cookie) {
      let cookies = document.cookie.split(";");
      if (cookies.length > 1) {
        return "";
      } else {
        let loginCookie = cookies[0].split("=");
        if (loginCookie[0] == "login") {
          loginCookie = loginCookie[1];
          this.$router.push(`admin`);
        } else {
          return "";
        }
      }
    }
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
      let adminDb = `https://localhost:5001/api/admins/user/${this.name}`;
      axios
        .get(adminDb)
        .then(response => {
          if (response.status == 200) {
            if (
              response.data.username == this.name &&
              response.data.password == this.pass
            ) {
              let name = "login";
              let expires;
              let date = new Date();
              date.setTime(date.getTime() + 1 * 24 * 60 * 60 * 1000);
              expires = "; expires=" + date.toGMTString();
              document.cookie = name + "=" + response.data.id + expires;
              this.$router.push(`admin`);
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
.login {
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 70px calc(100vh - 70px) auto;
  width: 100%;
}

.wrapper {
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
  border-radius: 20px;
  padding: 20px 20px 25px 20px;
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
  border: 2px solid black;
  border-radius: 5px;
  padding: 5px;
  font-family: var(--paragraph);
}

form label {
  padding: 0 0 2px 3px;
}

form button {
  background: black;
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
  color: black;
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