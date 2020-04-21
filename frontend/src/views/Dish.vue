<template>
  <section class="dish">
    <router-view>
      <DetailedDish></DetailedDish>
    </router-view>

    <section class="related">
      <header>
        <h3>Andre retter</h3>
      </header>
      <DishList :dishes="dishes"></DishList>
    </section>
  </section>
</template>

<script>
import axios from "axios";
import DetailedDish from "../components/user/DetailedDish";
import DishList from "../components/user/DishList";

export default {
  name: "Dish",
  components: {
    DishList,
    DetailedDish
  },
  data() {
    return {
      theDish: {},
      dishes: []
    };
  },
  created() {
    const webAPIUrl = `https://localhost:5001/dishes/`;
    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  }
};
</script>

<style scoped>
.dish {
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: repeat(2, auto);
  width: 100%;
  gap: 20px;
}

.related {
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
  padding: 0 20px 60px 20px;
}

.related header {
  padding: 40px 0 10px 0;
}

@media only screen and (min-width: 800px) {
  .dish {
    grid-template-rows: 400px auto;
  }
}
</style>