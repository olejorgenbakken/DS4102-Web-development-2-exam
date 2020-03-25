<template>
  <nav class="global-navigation">
    <section class="user-nav nav" v-if="$route.params.id == null">
      <a href="#menu">Meny</a>
      <router-link :to="{ name: 'admin', params: { id: 1 }}">Logg inn</router-link>
    </section>
    <section class="admin-nav nav" v-else>
      <a href="#menu-table">Retter på menyen</a>
      <router-link to="/">Forside</router-link>
    </section>
  </nav>
</template>

<script>
export default {
  name: "Navigation",
  props: {
    direction: String
  }
};
</script>

<style scoped>
.nav {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 20px;
}

.nav a {
  color: var(--black);
  font-family: var(--subheading);
  text-transform: uppercase;
  font-weight: 700;
}
</style>