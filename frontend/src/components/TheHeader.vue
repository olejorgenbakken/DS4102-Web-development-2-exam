<template>
  <header class="global-header" :style="`color: ${colors.logo}`">
    <router-link :to="{name: 'Homepage'}">
      <h1 :style="`color: ${colors.logo}`">{{sitetitle}}</h1>
    </router-link>
    <Navigation :color="colors.logo"></Navigation>
  </header>
</template>

<script>
import { store } from "../store.js";
import axios from "axios";
import Navigation from "./Navigation.vue";

export default {
  name: "Header",
  props: {
    sitetitle: String
  },
  data() {
    return {
      colors: {}
    };
  },
  components: {
    Navigation
  },
  created() {
    let settingsURL = `https://localhost:5001/settings`;
    axios.get(settingsURL).then(response => {
      if (response.status > 200) {
        let settingsURL = `https://localhost:5001/settings/`;
        this.colors = {
          logo: store.state.colors.logo,
          highlighted: store.state.colors.highlighted,
          highlightedText: store.state.colors.highlightedText
        };
        axios.post(settingsURL, this.colors);
      } else {
        this.colors = response.data;
      }
    });
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
