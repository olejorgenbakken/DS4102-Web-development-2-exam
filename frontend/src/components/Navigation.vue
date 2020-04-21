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
  font-family: var(--heading);
  font-weight: 900;
  font-size: 1em;
  letter-spacing: 1px;
  transition: 0.2s ease-in-out;
  cursor: pointer;
  background: transparent;
}
</style>