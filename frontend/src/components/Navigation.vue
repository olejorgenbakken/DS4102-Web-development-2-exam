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
import { store } from "../store.js";

export default {
  name: "Navigation",
  data() {
    return {
      loggedIn: store.state.loggedIn,
      isAdmin: store.state.isAdmin
    };
  },
  watch: {
    $route() {
      this.loggedIn = store.state.loggedIn;
      this.isAdmin = store.state.isAdmin;
    }
  },
  methods: {
    logout() {
      store.state.loggedIn = false;
      this.loggedIn = store.state.loggedIn;
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