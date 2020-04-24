<template>
  <section class="wrapper">
    <section class="login">
      <LoginForm></LoginForm>
    </section>
    <section class="create-user"></section>
  </section>
</template>

<script>
import LoginForm from "../components/LoginForm";

export default {
  name: "Login",
  components: {
    LoginForm
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
  }
};
</script>

<style scoped>
.wrapper {
  display: grid;
  grid-template-rows: 600px auto;
}

.login {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background: url(https://images.unsplash.com/photo-1533038590840-1cde6e668a91?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1868&q=80);
  background-size: cover;
  background-position: center bottom;
}

.create-user {
}
</style>