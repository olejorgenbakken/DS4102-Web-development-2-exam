<template>
  <table class="dishes">
    <tr class="rows headings">
      <th>Bilde</th>
      <th>Navn</th>
      <th>Beskrivelse</th>
      <th>Type</th>
      <th>Pris (kr)</th>
      <th>Fremhevet</th>
      <th>Slett</th>
    </tr>
    <tr v-for="dish in dishes" :key="dish.id" class="rows">
      <td class="photo">
        <img :src="'https:/localhost:5001/images/' + dish.photo" />
      </td>
      <td class="name">
        <input v-model="dish.name" @click="highlightInput" />
      </td>
      <td>
        <textarea v-model="dish.description"></textarea>
      </td>
      <td v-if="dish.type == 'Sashimi'">Sashimi</td>
      <td v-else-if="dish.type == 'Nigiri'">Nigiri</td>
      <td v-else-if="dish.type == 'Vegetar'">Vegetar</td>
      <td v-else>Maki</td>
      <td>{{dish.price}}</td>
      <td v-if="dish.highlighted">Ja</td>
      <td v-else>Nei</td>
      <td>
        <button @click="deleteDish" :id="dish.id" class="delete-btn">Slett</button>
      </td>
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
    let webAPIUrl = "https://localhost:5001/api/dishes/";

    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  },
  methods: {
    deleteDish(e) {
      let webAPIUrl = `https://localhost:5001/api/dishes/${e.target.id}`;
      console.log(e.target.id);
      axios.delete(webAPIUrl).then(result => {
        this.deleteStatus = JSON.stringify(result.data);
      });
    },
    highlightInput(e) {
      console.log(e.target);
    }
  }
};
</script>

<style scoped>
.dishes {
  width: 100%;
  margin: 0 auto;
  background: var(--color);
  padding: 10px;
  display: grid;
  gap: 10px;
  font-family: sans-serif;
}

.rows {
  display: grid;
  grid-template-columns: 50px 200px 1fr 100px 80px 100px 70px;
  text-align: left;
  align-items: flex-start;
  gap: 20px;
}

.headings {
  align-items: flex-end;
  font-family: var(--subheading);
  font-size: 0.9em;
}

input,
textarea {
  width: 100%;
  height: 100%;
}

.name {
  font-weight: bold;
}

.photo {
  height: 50px;
}

.photo img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.delete-btn {
  background: red;
  color: white;
  padding: 5px 10px;
  border-radius: 5px;
  font-weight: 700;
  font-family: var(--subheading);
  font-size: 0.9em;
}
</style>