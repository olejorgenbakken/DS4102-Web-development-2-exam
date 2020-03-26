<template>
  <main class="mainpage">
    <TheHeader></TheHeader>
    <DishHighlight
      :id="highlighted.id"
      :photo="highlighted.photo"
      :name="highlighted.name"
      :price="highlighted.price"
      :description="highlighted.description"
    ></DishHighlight>
    <DishList :dishes="dishes"></DishList>
    <TheFooter></TheFooter>
  </main>
</template>

<script>
import axios from "axios";
import TheHeader from "../components/TheHeader.vue";
import DishHighlight from "../components/user/DishHighlight.vue";
import DishList from "../components/user/DishList.vue";
import TheFooter from "../components/TheFooter.vue";

export default {
  name: "UserHome",
  components: {
    TheHeader,
    DishHighlight,
    DishList,
    TheFooter
  },
  data() {
    return {
      highlighted: {},
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
    const webAPIUrl = "https://localhost:5001/api/dishes/";

    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
      response.data.forEach(dish => {
        if (dish.highlighted) {
          this.highlighted = dish;
        }
      });
    });
  }
};
</script>