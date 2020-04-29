<template>
  <article class="order">
    <header>
      <h3>Ordrenr. {{order.id}}</h3>
      <label>
        Dato:
        <b>{{formattedDate}}</b>
      </label>
    </header>
    <OrderItemList :items="JSON.parse(order.items)"></OrderItemList>
    <footer>
      <h4>Sum: {{order.total}}kr</h4>
    </footer>
  </article>
</template>

<script>
import OrderItemList from "./OrderItemList";
export default {
  name: "Order",
  props: {
    order: Object
  },
  components: {
    OrderItemList
  },
  data() {
    return {
      formattedDate: ""
    };
  },
  mounted() {
    let date = new Date(this.order.date);
    this.formattedDate = `${date.getDate()}.${date.getMonth() +
      1}.${date.getFullYear()}`;
  }
};
</script>

<style scoped>
.order {
  background: var(--card-background);
}

.order header {
  padding: 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 5px;
}

.order footer {
  padding: 20px;
}
</style>