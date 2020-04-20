<template>
  <footer class="footer" :style="`background: ${color}`">
    <section class="content">
      <h2 class="footer-title">Sushi restaurant</h2>
    </section>
  </footer>
</template>

<script>
import axios from "axios";
export default {
  name: "Footer",
  data() {
    return {
      color: "#ffffff"
    };
  },
  created() {
    const settings = `https://localhost:5001/settings/1`;
    axios.get(settings).then(response => {
      this.color = response.data.color;
    });
  }
};
</script>

<style scoped>
.footer {
  background: black;
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
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
