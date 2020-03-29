<template>
  <section id="menu">
    <header>
      <h3>Meny</h3>
    </header>
    <table class="dishes">
      <thead class="headings">
        <tr class="rows">
          <th>Bilde</th>
          <th>Navn</th>
          <th>Beskrivelse</th>
          <th>Type</th>
          <th>Pris (kr)</th>
          <th>Fremhevet</th>
          <th>Slett</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="dish in dishes" :key="dish.id" class="rows">
          <td class="photo">
            <input
              type="file"
              name="upload-img"
              @change="sendData"
              :dish="dish.id"
              class="uploadedPic"
            />
            <img
              :src="'https:/localhost:5001/images/' + dish.photo"
              :dish="dish.id"
              class="dish-photo"
            />
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
            <select v-model="dish.type" @change="sendData" :dish="dish.id" class="type">
              <option disabled value>Velg en</option>
              <option v-for="type in dishTypes" :key="type">{{type}}</option>
            </select>
          </td>
          <td>
            <input
              type="number"
              v-model="dish.price"
              @focusout="sendData"
              :dish="dish.id"
              class="price"
            />
          </td>
          <td>
            <select
              v-model="dish.highlighted"
              @change="sendData"
              :dish="dish.id"
              class="highlighted"
            >
              <option disabled value>Fremhevet?</option>
              <option value="true">Ja</option>
              <option value="false">Nei</option>
            </select>
          </td>
          <td>
            <button @click="deleteDish" :id="dish.id" class="delete-btn">Slett</button>
          </td>
        </tr>
      </tbody>
    </table>
    <aside class="updated"></aside>
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
    // Deletes a dish from the database using the div's "dish" value.
    deleteDish(e) {
      let updateDiv = document.querySelector(".updated");
      let webAPIUrl = `https://localhost:5001/api/dishes/${e.target.id}`;
      axios
        .delete(webAPIUrl)
        .then(result => {
          this.deleteStatus = JSON.stringify(result.data);
          updateDiv.innerHTML = `<p>${result.data.name} slettet fra menyen</p>`;
          updateDiv.classList.add("success");
          setTimeout(() => {
            updateDiv.classList.remove("success");
          }, 3000);
        })
        .catch(() => {
          updateDiv.innerHTML = `<p>Kunne ikke slette retten fra menyen</p>`;
          updateDiv.classList.add("fail");
          setTimeout(() => {
            updateDiv.classList.remove("fail");
          }, 3000);
        });
    },
    // Update method being called whenever a change is made on the dish,
    // with feeback for success and failure.
    sendData(e) {
      let webAPIUrl = "https://localhost:5001/api/dishes/";
      let updateDiv = document.querySelector(".updated");
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
          updatedDish.type = document.querySelector(
            ".type[dish='" + oldDish.id + "']"
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
          axios
            .put(webAPIUrl, updatedDish)
            .then(() => {
              updateDiv.innerHTML = "<p>Endringer lagret ✨</p>";
              updateDiv.classList.add("success");
              setTimeout(() => {
                updateDiv.classList.remove("success");
              }, 3000);
            })
            .catch(() => {
              updateDiv.innerHTML = "<p>Endringer ikke lagret</p>";
              updateDiv.classList.add("fail");
              setTimeout(() => {
                updateDiv.classList.remove("fail");
              }, 3000);
            });
        });
    }
  }
};
</script>

<style scoped>
#menu header {
  padding: 20px 0 10px 5px;
  font-family: var(--subheading);
}
.dishes {
  text-align: left;
  border-collapse: collapse;
  width: 100%;
}
thead {
  font-family: var(--subheading);
  font-size: 0.9em;
}
th,
td {
  padding: 0 8px;
}

th {
  background: var(--color);
  padding: 10px 8px;
}

td {
  position: relative;
  border: 1px solid lightgray;
  font-family: var(--paragraph);
}
.name {
  width: 100%;
}
.photo {
  position: relative;
  width: 60px;
  height: 60px;
}
.photo img {
  position: absolute;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
  object-fit: cover;
  z-index: 0;
}
.uploadedPic {
  position: absolute;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
  cursor: pointer;
  opacity: 0;
  z-index: 1;
}
.price {
  max-width: 70px;
}
.description {
  min-height: 40px;
  width: 100%;
  min-width: 200px;
  resize: none;
  outline: none;
}

.delete-btn {
  transition: 0.2s ease-in-out;
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgb(61, 0, 0);
  color: white;
}

.delete-btn:hover {
  background: red;
}

.updated {
  transition: 0.5s ease-in-out;
  position: fixed;
  top: -30px;
  left: 0;
  width: 100%;
  min-height: 30px;
  padding: 20px 50px;
  display: flex;
  align-items: center;
  justify-content: center;
  color: white;
  opacity: 0;
}

.updated.success {
  opacity: 1;
  top: 0;
  background: green;
}

.updated.fail {
  opacity: 1;
  top: 0px;
  background: red;
}
</style>