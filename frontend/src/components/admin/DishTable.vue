<template>
  <table class="dishes">
    <tr class="rows">
      <th>Bilde</th>
      <th>Navn</th>
      <th>Beskrivelse</th>
      <th>Type</th>
      <th>Pris (kr)</th>
      <th>Fremhevet</th>
    </tr>
    <tr v-for="dish in dishes" :key="dish.id" class="rows">
      <td class="photo">
        <img :src="dish.photo" />
      </td>
      <td class="name">{{dish.name}}</td>
      <td>{{dish.description}}</td>
      <td v-if="dish.type == 'Main'">Hovedrett</td>
      <td v-else-if="dish.type == 'Dessert'">Dessert</td>
      <td v-else-if="dish.type == 'Drink'">Drikke</td>
      <td v-else>Starter</td>
      <td>{{dish.price}}</td>
      <td v-if="dish.highlighted">Ja</td>
      <td v-else>Nei</td>
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
  padding: 10px;
  display: grid;
  gap: 10px;
}

.rows {
  display: grid;
  grid-template-columns: 70px repeat(2, 1fr) 150px 100px 100px;
  text-align: left;
  align-items: center;
}

.name {
  font-weight: bold;
}

.photo {
  height: 50px;
}

.photo img {
  height: 50px;
  width: 50px;
  object-fit: cover;
}
</style>