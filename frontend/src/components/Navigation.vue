<template>
  <nav class="global-navigation">
    <section class="admin-nav nav" v-if="$route.name == 'admin'">
      <p @click="logout">Logg Ut</p>
    </section>
    <section class="user-nav nav" v-else>
      <router-link :to="{ name: 'Login'}">Logg inn</router-link>
    </section>
  </nav>
</template>

<script>
export default {
  name: "Navigation",
  props: {
    direction: String
  },
  methods: {
    logout() {
      sessionStorage.removeItem("user");
      this.$router.push({ name: "Frontpage" });
    }
  }
};
</script>

<style scoped>
.nav {
  display: grid;
  grid-template-columns: repeat(1, auto);
  gap: 20px;
}

.nav a,
.nav p {
  color: var(--black);
  font-family: var(--subheading);
  text-transform: uppercase;
  font-weight: 700;
  cursor: pointer;
}
</style>