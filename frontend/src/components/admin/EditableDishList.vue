<template>
  <section class="dishes">
    <DishItem v-for="dish in dishes" :key="dish.id" :id="dish.id"></DishItem>
  </section>
</template>

<script>
import axios from "axios";
import DishItem from "./EditableDishItem";

export default {
  name: "DishTable",
  components: {
    DishItem
  },
  data() {
    return {
      dishes: []
    };
  },
  created() {
    let webAPIUrl = "https://localhost:5001/api/dishes/";

    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  }
};
</script>

<style scoped>
.dishes {
  display: grid;
  grid-template-columns: 1fr;
  gap: 40px;
}

@media only screen and (min-width: 600px) {
  .dishes {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media only screen and (min-width: 1000px) {
  .dishes {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media only screen and (min-width: 1100px) {
  .dishes {
    grid-template-columns: 1fr;
    gap: 20px;
  }
}
</style>