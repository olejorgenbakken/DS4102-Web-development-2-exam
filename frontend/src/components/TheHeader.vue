<template>
  <header class="header">
    <section class="content">
      <router-link to="/">
        <h1 class="frontpage-title">SUSHI Restaurant</h1>
      </router-link>
      <Navigation :direction="'row'"></Navigation>
    </section>
  </header>
</template>

<script>
import Navigation from "./Navigation.vue";

export default {
  name: "Introduction",
  components: {
    Navigation
  }
};
</script>

<style scoped>
.header {
  width: 100%;
  padding: 0 0px;
}

.content {
  display: grid;
  grid-template-columns: 1fr;
  text-align: center;
  align-items: center;
  gap: 10px;
  margin: 0 auto;
  width: 100%;
  max-width: 1000px;
  padding: 20px 10px;
}

.frontpage-title {
  font-size: 1.5em;
  font-weight: 900;
  color: var(--black);
}

@media only screen and (min-width: 600px) {
  .content {
    padding: 20px 30px;
    height: 15vh;
    text-align: left;
    grid-template-columns: 1fr auto;
    align-items: center;
  }
}
</style>
