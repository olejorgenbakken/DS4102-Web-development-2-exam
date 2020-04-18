<template>
  <header class="header">
    <router-link to="/">
      <h1 class="frontpage-title">Sushi restaurant</h1>
    </router-link>
    <Navigation></Navigation>
  </header>
</template>

<script>
import Navigation from "./Navigation.vue";

export default {
  name: "Header",
  components: {
    Navigation
  }
};
</script>

<style scoped>
.header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  max-width: 800px;
  margin: 0 auto;
}

h1 {
  font-weight: 900;
  font-size: 1.3em;
}

@media only screen and (min-width: 700px) {
  h1 {
    font-size: 1.5em;
  }
}
</style>
