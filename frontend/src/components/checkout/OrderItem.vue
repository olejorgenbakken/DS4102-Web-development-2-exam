<template>
  <article class="card item">
    <figure>
      <img :src="`https:/localhost:5001/images/${dish.photo}`" />
    </figure>
    <section class="info">
      <section class="info-text">
        <h3>{{dish.name}}</h3>
        <p>{{dish.price}}kr</p>
      </section>
      <section class="amount">
        <label>Antall:</label>
        <select v-model="amount">
          <option v-for="n in 10" :key="n" :value="n">{{n}}</option>
        </select>
      </section>

      <button class="del-btn">Fjern fra ordre</button>
    </section>
  </article>
</template>

<script>
import { store } from "../../store.js";
import axios from "axios";

export default {
  name: "OrderItem",
  props: {
    id: Number
  },
  data() {
    return {
      order: store.state.order,
      dish: {},
      amount: 1
    };
  },
  created() {
    let dishesURL = `https://localhost:5001/dishes/${this.id}`;
    axios.get(dishesURL).then(response => {
      this.dish = response.data;
    });

    this.order.forEach(item => {
      if (item.id == this.id) {
        this.amount = item.amount;
      }
    });
  },
  updated() {
    store.state.order.forEach(item => {
      if (item.id == this.id) {
        item.amount = this.amount;
      }
    });
  }
};
</script>

<style scoped>
.item {
  display: grid;
  grid-template-columns: 1fr;
}

figure {
  width: 100%;
  height: 200px;
}

.info {
  display: grid;
  grid-template-columns: 1fr;
  align-items: center;
  gap: 10px;
  padding: 10px;
}

.info h3 {
  margin-bottom: 5px;
}

@media only screen and (min-width: 400px) {
  .info {
    grid-template-columns: 1fr 100px 100px;
  }

  .amount {
    grid-column: 3;
  }

  .del-btn {
    grid-column: 2 / span 2;
    justify-self: right;
    max-width: max-content;
  }
}
</style>