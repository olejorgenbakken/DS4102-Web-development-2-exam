<template>
  <nav class="global-navigation">
    <section class="nav-content" v-if="loggedIn && !isAdmin">
      <router-link :to="{name: 'Checkout'}">Handlekurv</router-link>
      <p class="last" @click="logout">Logg ut</p>
    </section>

    <section class="nav-content" v-else-if="loggedIn && isAdmin">
      <router-link :to="{name: 'Checkout'}">Handlekurv</router-link>
      <router-link :to="{name: 'Admin'}">Dashboard</router-link>
      <p class="last" @click="logout">Logg ut</p>
    </section>

    <section class="nav-content" v-else>
      <router-link :to="{name: 'Checkout'}">Handlekurv</router-link>
      <router-link class="last" :to="{name: 'Login'}">Logg inn</router-link>
    </section>
  </nav>
</template>

<script>
import axios from "axios";

export default {
  name: "Navigation",
  data() {
    return {
      loggedIn: null,
      isAdmin: null
    };
  },
  created() {
    if (document.cookie) {
      let cookies = document.cookie.split(";");
      if (cookies.length > 1) {
        return "";
      } else {
        let loginCookie = cookies[0].split("=");
        if (loginCookie[0] == "login") {
          let userID = loginCookie[1];
          let userDB = `https://localhost:5001/users/id/${userID}`;
          axios.get(userDB).then(response => {
            console.log(response);
            this.loggedIn = true;
            this.isAdmin = response.data.admin;
          });
        }
      }
    }
  },
  methods: {
    logout() {
      document.cookie = "login" + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT;";
      this.$router.push({ name: "Homepage" });
    }
  }
};
</script>

<style scoped>
a,
p {
  font-family: var(--heading);
  font-weight: 700;
  cursor: pointer;
  color: inherit;
}

a,
p {
  margin: 0 10px;
}

.last {
  margin-right: 0;
}

.nav-content {
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
}
</style>