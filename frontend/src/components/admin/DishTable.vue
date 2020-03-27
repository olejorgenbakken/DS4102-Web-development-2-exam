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
          <option>Maki</option>
          <option>Sashimi</option>
          <option>Nigiri</option>
          <option>Vegetar</option>
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
</template>

<script>
import axios from "axios";

export default {
  name: "DishTable",
  data() {
    return {
      dishes: []
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
  grid-template-columns: 50px 200px 1fr 120px 80px 100px 70px;
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
  position: relative;
}

.chosenPic {
  position: absolute;
  top: 0;
  left: 0;
  height: 100%;
  opacity: 0;
  width: 100%;
  cursor: pointer;
  z-index: 2;
}

.photo img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.dish-type {
  display: grid;
  grid-template-columns: 1fr;
  gap: 5px;
}

.dish-type label {
  display: grid;
  grid-template-columns: 10px 1fr;
  gap: 10px;
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