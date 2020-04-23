<template>
  <section class="dish">
    <DetailedDish
      :name="dish.name"
      :id="dish.id"
      :photo="dish.photo"
      :type="dish.type"
      :price="dish.price"
      :ingredients="dish.ingredients"
      :description="dish.description"
    ></DetailedDish>
  </section>
</template>

<script>
import axios from "axios";
import DetailedDish from "../components/user/DetailedDish";

export default {
  name: "Dish",
  components: {
    DetailedDish
  },
  data() {
    return {
      dish: {}
    };
  },
  watch: {
    $route() {
      let webAPIUrl = `https://localhost:5001/dishes/${this.$route.params.id}`;
      axios.get(webAPIUrl).then(response => {
        this.dish = response.data;
        this.dish.ingredients = JSON.parse(this.dish.ingredients);
        console.log(this.dish);
      });
    }
  },
  created() {
    let webAPIUrl = `https://localhost:5001/dishes/${this.$route.params.id}`;
    axios.get(webAPIUrl).then(response => {
      this.dish = response.data;
      this.dish.ingredients = JSON.parse(this.dish.ingredients);
    });
  }
};
</script>

<style scoped>
.dish {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
}

@media only screen and (min-width: 900px) {
  .dish {
    padding: 40px;
  }
}
</style>