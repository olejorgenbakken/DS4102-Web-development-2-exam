<template>
  <section class="order-history">
    <header>
      <h3>Historikk</h3>
    </header>
    <section class="order-history-orders">
      <Order v-for="order in orders" :key="order.id" :order="order"></Order>
    </section>
  </section>
</template>

<script>
import Order from "./Order";

export default {
  name: "OrderHistory",
  components: {
    Order
  },
  props: {
    orders: Array
  }
};
</script>

<style scoped>
.order-history header {
  margin-bottom: 10px;
}

.order-history-orders {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}
</style>