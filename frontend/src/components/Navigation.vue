<template>
  <nav class="global-navigation">
    <section class="admin-nav nav" v-if="$route.name == 'admin'">
      <a href="#upload">Legg til ny rett</a>
      <a href="#menu">Retter på menyen</a>
      <router-link to="/">Forside</router-link>
    </section>
    <section class="user-nav nav" v-else>
      <a href="#menu">Meny</a>
      <router-link :to="{ name: 'admin', params: { id: 1 }}">Logg inn</router-link>
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
  display: grid;
  grid-template-columns: repeat(3, auto);
  gap: 20px;
}

.nav a {
  color: var(--black);
  font-family: var(--subheading);
  text-transform: uppercase;
  font-weight: 700;
}
</style>