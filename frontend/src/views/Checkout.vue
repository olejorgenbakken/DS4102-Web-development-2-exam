<template>
  <section class="checkout">
    <router-view></router-view>
  </section>
</template>

<script>
export default {
  name: "Checkout",
  created() {
    if (localStorage.getItem("order")) {
      this.$router.push({ name: "Order" });
    } else {
      this.$router.push({ name: "NoItems" });
    }
  }
};
</script>

<style scoped>
.checkout {
  width: 100%;
  padding: 0 10px 40px 10px;
  margin: 0 auto;
}
</style>