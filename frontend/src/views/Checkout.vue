<template>
  <section class="checkout">
    <router-view></router-view>
  </section>
</template>

<script>
import { store } from "../store.js";
export default {
  name: "Checkout",
  data() {
    return {
      order: store.state.order
    };
  },
  created() {
    if (this.order) {
      this.$router.push({ name: "Overview" });
    } else {
      this.$router.push({ name: "NoItems" });
    }
  }
};
</script>

<style scoped>
.checkout {
  width: 100%;
  max-width: 1200px;
  padding: 0 10px 40px 10px;
  margin: 0 auto;
}
</style>