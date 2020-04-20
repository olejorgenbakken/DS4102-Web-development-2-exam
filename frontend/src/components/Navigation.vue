<template>
  <nav class="global-navigation">
    <section class="admin-nav" v-if="$route.name == 'Admin'">
      <button @click="logout" :style="`color: ${color}`">Logg ut</button>
    </section>
    <section class="user-nav nav" v-else>
      <router-link :to="{ name: 'Login'}" :style="`color: ${color}`">Logg inn</router-link>
    </section>
  </nav>
</template>

<script>
export default {
  name: "Navigation",
  props: {
    color: String,
    text: String
  },
  methods: {
    logout() {
      document.cookie = "login" + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT;";
      this.$router.push("/");
    }
  }
};
</script>

<style scoped>
button,
a {
  padding: 5px 10px;
  border-radius: 5px;
  font-family: var(--heading);
  font-weight: 900;
  letter-spacing: 1px;
  font-size: 0.8em;
  transition: 0.2s ease-in-out;
}

@media only screen and (min-width: 700px) {
  button,
  a {
    font-size: 0.93em;
  }
}
</style>