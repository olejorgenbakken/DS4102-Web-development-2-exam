<template>
  <footer class="footer">
    <section class="content">
      <header class="content-header">
        <router-link to="/">
          <h1 class="frontpage-title" :style="`color: ${colors.logo}`">{{sitetitle}}</h1>
        </router-link>
      </header>
    </section>
  </footer>
</template>

<script>
import { store } from "../store.js";
import axios from "axios";

export default {
  name: "Footer",
  props: {
    sitetitle: String
  },
  data() {
    return {
      colors: {}
    };
  },
  created() {
    let settingsURL = `https://localhost:5001/settings`;
    axios.get(settingsURL).then(response => {
      if (response.status > 200) {
        this.colors = {
          logo: store.state.colors.logo,
          highlighted: store.state.colors.highlighted,
          highlightedText: store.state.colors.highlightedText
        };
      } else {
        this.colors = response.data;
      }
    });
  }
};
</script>

<style scoped>
.footer {
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  z-index: 3;
  padding: 50px 0;
}

.content {
  width: 100%;
  max-width: 1000px;
  padding: 20px;
  margin: 0 auto;
}

.footer-title {
  font-weight: 900;
}
</style>
