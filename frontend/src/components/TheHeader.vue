<template>
  <header class="header">
    <router-link to="/">
      <h1 class="frontpage-title" :style="`color: ${settings.color}`">Sushi restaurant</h1>
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
.header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  height: 70px;
  width: 100%;
  max-width: 800px;
  padding: 0 20px;
  margin: 0 auto;
}

h1 {
  font-weight: 900;
  font-size: 1.3em;
}

@media only screen and (min-width: 700px) {
  .header {
    height: 100px;
  }

  h1 {
    font-size: 1.5em;
  }
}
</style>
