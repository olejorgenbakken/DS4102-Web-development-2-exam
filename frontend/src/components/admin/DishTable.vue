<template>
  <v-data-table
    :headers="headers"
    :items="dishes"
    :items-per-page="15"
    class="elevation-1 table"
    id="menu-table"
  ></v-data-table>
</template>

<script>
import axios from "axios";

export default {
  name: "DishTable",
  data() {
    return {
      headers: [
        { text: "Navn", align: "start", sortable: true, value: "name" },
        { text: "Beskrivelse", value: "description", sortable: false },
        { text: "Ingredienser", value: "ingredients", sortable: false },
        { text: "Bilde (URL)", value: "photo", sortable: false },
        { text: "Pris (kr)", value: "price" }
      ],
      dishes: [
        {
          name: "Frozen Yogurt",
          price: 159
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

<style scoped>
.table {
  width: 100%;
  max-width: 1200px;
  padding: 20px;
  margin: 0 auto;
}
</style>