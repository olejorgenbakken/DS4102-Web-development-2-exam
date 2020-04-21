<template>
  <section class="dishes">
    <DishItem v-for="dish in dishesToShow" :key="dish.id" :id="dish.id"></DishItem>
  </section>
</template>

<script>
import axios from "axios";
import DishItem from "./EditableDishItem";

export default {
  name: "EditableDishList",
  components: {
    DishItem
  },
  data() {
    return {
      dishesToShow: Array,
      allDishes: Array
    };
  },
  beforeCreate() {
    let webAPIUrl = `https://localhost:5001/dishes/`;
    axios.get(webAPIUrl).then(response => {
      this.dishesToShow = response.data;
      this.allDishes = this.dishesToShow;
    });
  },
  watch: {
    $route() {
      let matchingDishes = [];
      if (
        this.$route.query.dish != undefined &&
        this.$route.query.type != undefined
      ) {
        this.allDishes.forEach(dish => {
          if (
            (dish.name
              .toLowerCase()
              .includes(this.$route.query.dish.toLowerCase()) ||
              dish.description
                .toLowerCase()
                .includes(this.$route.query.dish.toLowerCase())) &&
            dish.type
              .toLowerCase()
              .includes(this.$route.query.type.toLowerCase())
          ) {
            matchingDishes.push(dish);
          }
        });
        this.dishesToShow = matchingDishes;
      } else if (this.$route.query.dish != undefined) {
        this.allDishes.forEach(dish => {
          if (
            dish.name
              .toLowerCase()
              .includes(this.$route.query.dish.toLowerCase()) ||
            dish.description
              .toLowerCase()
              .includes(this.$route.query.dish.toLowerCase())
          ) {
            matchingDishes.push(dish);
          }
        });
        this.dishesToShow = matchingDishes;
      } else if (this.$route.query.type != undefined) {
        this.allDishes.forEach(dish => {
          if (
            dish.type
              .toLowerCase()
              .includes(this.$route.query.type.toLowerCase())
          ) {
            matchingDishes.push(dish);
          }
        });
        this.dishesToShow = matchingDishes;
      } else {
        this.dishesToShow = this.allDishes;
      }
    }
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