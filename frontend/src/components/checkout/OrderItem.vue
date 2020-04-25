<template>
  <article class="card item">
    <figure>
      <img :src="`https:/localhost:5001/images/${dish.photo}`" />
    </figure>
    <section class="info">
      <h3>{{dish.name}}</h3>
      <p>{{dish.price}}kr</p>
      <button class="del">Fjern fra ordre</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "OrderItem",
  props: {
    id: Number
  },
  data() {
    return {
      dish: {}
    };
  },
  created() {
    let dishesURL = `https://localhost:5001/dishes/${this.id}`;
    axios.get(dishesURL).then(response => {
      this.dish = response.data;
    });
  }
};
</script>

<style>
.item {
  display: grid;
  grid-template-columns: 1fr;
}

.info {
  padding: 10px;
}

figure {
  width: 100%;
  height: 200px;
}
</style>