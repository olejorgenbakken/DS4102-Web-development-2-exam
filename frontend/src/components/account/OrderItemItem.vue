<template>
  <router-link class="dish" :to="{ name: 'Dish', params: {id: dish.id}}">
    <figure class="photo">
      <img :src="`https:/localhost:5001/images/${dish.photo}`" />
    </figure>
    <section class="info">
      <h4 class="title">{{dish.name}}</h4>
      <h5 class="price">{{dish.price}}kr</h5>
    </section>
  </router-link>
</template>

<script>
import axios from "axios";

export default {
  name: "OrderItemItem",
  props: {
    id: Number
  },
  data() {
    return {
      dish: {}
    };
  },
  created() {
    let dishesDB = `https://localhost:5001/dishes/${this.id}`;
    axios.get(dishesDB).then(response => {
      this.dish = response.data;
    });
  }
};
</script>

<style scoped>
.dish {
  flex: none;
  height: 100%;
  width: 60%;
  margin-right: 20px;
  display: grid;
  grid-template-rows: 200px auto;
  background: var(--footer);
}

.dish {
  color: var(--text);
}

.photo {
  height: 200px;
}

.info {
  padding: 10px;
}

.title {
  font-size: 1.1em;
}

.price {
  font-size: 1em;
  margin-top: 5px;
  font-weight: 500;
}
</style>