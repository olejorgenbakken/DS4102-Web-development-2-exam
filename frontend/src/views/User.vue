<template>
  <main class="mainpage">
    <TheHeader></TheHeader>
    <DishHighlight
      :id="dishes[1].id"
      :photo="dishes[1].photo"
      :name="dishes[1].name"
      :price="dishes[1].price"
      :description="dishes[1].description"
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
    });
  }
};
</script>