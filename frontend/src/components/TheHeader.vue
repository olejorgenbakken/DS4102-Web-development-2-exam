<template>
  <header class="global-header">
    <router-link to="/">
      <h1 :style="`color: ${settings.color}`">Sushi restaurant</h1>
    </router-link>
    <Navigation :color="settings.color" :text="settings.text"></Navigation>
  </header>
</template>

<script>
import axios from "axios";
import Navigation from "./Navigation.vue";

export default {
  name: "Header",
  components: {
    Navigation
  },
  data() {
    const settings = `https://localhost:5001/settings/1`;
    axios.get(settings).then(response => {
      this.settings = response.data;
    });

    return {
      settings: {}
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
