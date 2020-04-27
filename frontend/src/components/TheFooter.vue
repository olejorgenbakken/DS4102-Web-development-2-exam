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
export default {
  name: "Footer",
  props: {
    sitetitle: String
  },
  data() {
    return {
      colors: store.state.colors
    };
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
