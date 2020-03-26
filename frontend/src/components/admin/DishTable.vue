<template>
  <table class="dishes">
    <tr class="headings">
      <th>Navn</th>
      <th>Beskrivelse</th>
      <th>Pris (kr)</th>
    </tr>
    <tr v-for="dish in dishes" :key="dish.name">
      <td class="name">{{dish.name}}</td>
      <td>{{dish.description}}</td>
      <td>{{dish.price}}</td>
    </tr>
  </table>
</template>

<script>
import axios from "axios";

export default {
  name: "DishTable",
  data() {
    return {
      dishes: [
        {
          name: "Frozen Yogurt",
          price: 159
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

<style scoped>
.dishes {
  width: 100%;
  margin: 0 auto;
  background: rgb(233, 233, 233);
  padding: 5px 20px;
}

.headings {
  text-align: left;
}

.name {
  font-weight: bold;
}
</style>