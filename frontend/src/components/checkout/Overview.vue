<template>
  <section class="order-overview">
    <header class="order-overview-header">
      <h2>Handlekurv</h2>
    </header>
    <section class="order-items" @change="updateTotal">
      <OrderItem v-for="item in order" :key="item.id" :id="item.id"></OrderItem>
    </section>
    <section class="order-total">
      <h2>Oversikt over ordre</h2>
      <p>{{total}}</p>
    </section>
  </section>
</template>

<script>
import { store } from "../../store.js";

import OrderItem from "./OrderItem";

export default {
  name: "Overview",
  components: {
    OrderItem
  },
  data() {
    return {
      order: store.state.order,
      total: store.calculateTotal()
    };
  },
  methods: {
    updateTotal() {
      this.total = store.calculateTotal();
      console.log(store.calculateTotal());
    }
  }
};
</script>

<style scoped>
.order-overview {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

.order-items {
  width: 100%;
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}
</style>