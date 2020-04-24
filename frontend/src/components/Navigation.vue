<template>
  <nav class="global-navigation">
    <p v-if="$route.name == 'Admin'" @click="logout" :style="`color: ${color}`">Logg ut</p>
    <router-link v-else :to="{ name: 'Login'}" :style="`color: ${color}`">Logg inn</router-link>
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
a,
p {
  font-family: var(--heading);
  font-weight: 700;
  cursor: pointer;
}
</style>