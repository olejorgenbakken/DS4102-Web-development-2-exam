<template>
  <main>
    <DishList :dishes="dishes"></DishList>
  </main>
</template>

<script>
import axios from "axios";
import DishList from "../components/user/DishList.vue";

export default {
  name: "App",
  components: {
    DishList
  },
  data() {
    return {
      dishes: [
        {
          id: 0,
          name: "Placeholder",
          description: "A description",
          price: 0,
          photo:
            "https://toppng.com/uploads/preview/clipart-free-seaweed-clipart-draw-food-placeholder-11562968708qhzooxrjly.png",
          ingredients: '["empty", "efef"]'
        }
      ]
    };
  },
  created() {
    const webAPIUrl = "https://localhost:5001/dishes/";

    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  }
};
</script>
