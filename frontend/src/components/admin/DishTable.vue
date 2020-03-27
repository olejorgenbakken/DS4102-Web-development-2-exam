<template>
  <section id="menu">
    <header>
      <h3>Meny</h3>
    </header>
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
          <input type="file" name="upload-img" @change="sendData" :dish="dish.id" class="chosenPic" />
          <img :src="'https:/localhost:5001/images/' + dish.photo" />
        </td>
        <td>
          <input v-model="dish.name" @focusout="sendData" id="15" :dish="dish.id" class="name" />
        </td>
        <td>
          <textarea
            v-model="dish.description"
            @focusout="sendData"
            :dish="dish.id"
            class="description"
          ></textarea>
        </td>
        <td>
          <select v-model="dish.type" @change="sendData" :dish="dish.id">
            <option disabled value>Velg en</option>
            <option v-for="type in dishTypes" :key="type">{{type}}</option>
          </select>
        </td>
        <td>
          <input v-model="dish.price" @focusout="sendData" :dish="dish.id" class="price" />
        </td>
        <td>
          <select v-model="dish.highlighted" @change="sendData" :dish="dish.id" class="highlighted">
            <option disabled value>Fremhevet?</option>
            <option value="true">Ja</option>
            <option value="false">Nei</option>
          </select>
        </td>
        <td>
          <button @click="deleteDish" :id="dish.id" class="delete-btn">Slett</button>
        </td>
      </tr>
    </table>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "DishTable",
  data() {
    return {
      dishes: [],
      dishTypes: ["Forrett", "Maki", "Sashimi", "Nigiri", "Vegetar", "Drikke"]
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
    sendData(e) {
      let webAPIUrl = "https://localhost:5001/api/dishes/";
      let oldDish = `https://localhost:5001/api/dishes/${e.target.getAttribute(
        "dish"
      )}`;
      axios
        .get(oldDish)
        .then(response => {
          oldDish = response.data;
        })
        .then(() => {
          let updatedDish = oldDish;
          updatedDish.description = document.querySelector(
            ".description[dish='" + oldDish.id + "']"
          ).value;
          updatedDish.name = document.querySelector(
            ".name[dish='" + oldDish.id + "']"
          ).value;
          updatedDish.price = parseInt(
            document.querySelector(".price[dish='" + oldDish.id + "']").value
          );
          if (
            (updatedDish.highlighted =
              document.querySelector(".highlighted[dish='" + oldDish.id + "']")
                .value == "true")
          ) {
            updatedDish.highlighted = true;
          } else {
            updatedDish.highlighted = false;
          }
          console.log(updatedDish);
          axios.put(webAPIUrl, updatedDish);
        });
    }
  }
};
</script>

<style scoped>
</style>