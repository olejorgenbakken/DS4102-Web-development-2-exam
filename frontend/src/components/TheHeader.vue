<template>
  <header class="global-header" :style="`color: ${colors.logo}`">
    <router-link :to="{name: 'Homepage'}">
      <h1 :style="`color: ${colors.logo}`">{{sitetitle}}</h1>
    </router-link>
    <Navigation :color="colors.highlighted"></Navigation>
  </header>
</template>

<script>
import { store } from "../store.js";
import Navigation from "./Navigation.vue";

export default {
  name: "Header",
  props: {
    sitetitle: String
  },
  components: {
    Navigation
  },
  data() {
    return {
      colors: store.state.colors
    };
  }
};
</script>

<style scoped>
.global-header {
  width: 100%;
  max-width: 800px;
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 20px 10px;
}

h1 {
  text-align: center;
  margin-bottom: 10px;
}

@media only screen and (min-width: 570px) {
  .global-header {
    padding: 20px;
    flex-direction: row;
    justify-content: space-between;
  }
}

@media only screen and (min-width: 1000px) {
  .global-header {
    padding: 30px 20px;
  }
}
</style>
