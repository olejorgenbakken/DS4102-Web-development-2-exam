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
      <button class="del-btn">Fjern fra ordre</button>
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

<style scoped>
.item {
  display: flex;
  flex-direction: column;
}

figure {
  width: 100%;
  height: 100px;
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

.del-btn {
  max-width: max-content;
}

@media only screen and (min-width: 400px) {
  .item {
    display: grid;
    grid-template-columns: 100px 1fr;
  }

  figure {
    width: 100%;
    height: 100%;
  }

  .info {
    gap: 20px;
    padding: 15px;
  }
}
</style>