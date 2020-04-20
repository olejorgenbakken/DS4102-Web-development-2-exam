<template>
  <form class="upload card" @click="expand">
    <header>
      <h3>Legg til rett</h3>
    </header>
    <section class="name">
      <label>Navn</label>
      <input type="text" placeholder="Navn" autocomplete="off" v-model="dish.name" />
    </section>
    <section class="price">
      <label>Pris</label>
      <input type="number" placeholder="99" autocomplete="off" v-model="dish.price" />
    </section>
    <section class="type">
      <label>Type</label>
      <select v-model="dish.type">
        <option disabled hidden selected>Velg type</option>
        <option v-for="type in dishTypes" :value="type" :key="type">{{ type }}</option>
      </select>
    </section>
    <section class="desc">
      <label>Beskrivelse</label>
      <textarea placeholder="Beskrivelse" autocomplete="off" v-model="dish.description"></textarea>
    </section>
    <section class="highlighted">
      <label>Skal den fremheves?</label>
      <section class="input-highlighted">
        <label>
          <input type="radio" v-model="dish.highlighted" :value="true" />
          <p>Ja</p>
        </label>
        <label>
          <input type="radio" v-model="dish.highlighted" :value="false" />
          <p>Nei</p>
        </label>
      </section>
    </section>
    <section class="ingredients">
      <label>Ingredienser</label>
      <select multiple v-model="dish.ingredients">
        <option
          v-for="ingredient in ingredientList"
          :key="ingredient"
          :value="ingredient"
        >{{ingredient}}</option>
      </select>
    </section>
    <section class="selected-ingredients" v-if="dish.ingredients.length > 0">
      <label>Valgte ingredienser:</label>
      <p class="ingredient" v-for="n in dish.ingredients" :key="n" @click="removeIng">{{n}}</p>
    </section>
    <section class="photo">
      <label>Bilde</label>
      <figure class="figure">
        <input type="file" name="upload-img" id="new-pic" @input="showPicture" />
        <img :src="dish.photo" alt="Last opp et bilde" />
      </figure>
    </section>
    <button @click="addNewDish" class="submit-btn">Last opp ny rett</button>
  </form>
</template>

<script>
import axios from "axios";

export default {
  name: "AddNewDish",
  data() {
    return {
      dishTypes: ["Forrett", "Maki", "Sashimi", "Nigiri", "Vegetar", "Drikke"],
      multiple: "true",
      ingredientList: ["Agurk", "Chili", "Maki", "Wasabi", "idk"],
      dish: {
        ingredients: []
      }
    };
  },
  created() {
    this.ingredientList.sort((a, b) => {
      return a.localeCompare(b);
    });
  },
  methods: {
    expand() {
      window.scroll(0, document.querySelector("body").clientHeight);
      this.$el.classList.add("open");
    },
    removeIng(e) {
      this.dish.ingredients.forEach(ingredient => {
        if (ingredient == e.target.innerText) {
          const index = this.dish.ingredients.indexOf(ingredient);
          if (index > -1) {
            this.dish.ingredients.splice(index, 1);
          }
        }
      });
    },
    showPicture() {
      let input = this.$el.querySelector("#new-pic");
      if (input.files && input.files[0]) {
        let reader = new FileReader();
        reader.onload = e => {
          this.dish.photo = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    addNewDish(e) {
      e.preventDefault();
      let dishesURL = "https://localhost:5001/api/dishes";
      let imageData = new FormData();
      let input = this.$el.querySelector("#new-pic");
      imageData.append("file", input.files[0]);
      this.dish.price = parseInt(this.dish.price);
      this.dish.photo = input.files[0].name;
      this.dish.ingredients = JSON.stringify(this.dish.ingredients);
      axios.post(dishesURL, this.dish).then(() => {
        axios({
          method: "post",
          url: "https://localhost:5001/api/dishes/upload",
          data: imageData,
          config: { headers: { "Content-type": "multiplart/form-data" } }
        });
        this.dish = { ingredients: [] };
      });
    }
  }
};
</script>

<style scoped>
.upload {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: 50px repeat(8, auto);
  grid-template-areas:
    "header header"
    "name name"
    "price price"
    "type type"
    "desc desc"
    "high high"
    "ing ing"
    "sel-ing sel-ing"
    "pic pic"
    "btn btn";
  gap: 20px;
  height: 90px;
  font-family: var(--paragraph);
  overflow: hidden;
  transition: 0.2s ease-in-out;
}

.upload.open {
  overflow: auto;
  height: 300px;
}

input,
textarea,
select {
  border: 1px solid black;
  background: #ffffff;
  border-radius: 5px;
  padding: 5px;
}

header {
  grid-area: header;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

header::after {
  content: "Vis mer";
  padding: 10px;
  width: 100px;
  overflow: hidden;
  text-align: center;
  font-family: var(--heading);
  font-weight: 700;
  border: 2px solid black;
  border-radius: 10px;
  transition: 0.2s ease-in-out;
  opacity: 1;
}

.upload:hover:not(.open) header::after {
  background: black;
  color: white;
}

.upload.open header::after {
  opacity: 0;
}

.name {
  display: grid;
  gap: 2px;
  grid-area: name;
}

.price {
  display: grid;
  gap: 2px;
  grid-area: price;
}

.type {
  display: grid;
  gap: 2px;
  grid-area: type;
}

.desc {
  display: grid;
  gap: 2px;
  grid-area: desc;
}

.desc textarea {
  resize: vertical;
  min-height: 40px;
  height: 50px;
  max-height: 130px;
}

.ingredients {
  display: grid;
  gap: 2px;
  grid-area: ing;
}

.ingredients select {
  padding: 0;
  overflow: auto;
  height: 80px;
  transition: 0.2s ease-in-out;
}

.selected-ingredients {
  grid-area: sel-ing;
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  grid-template-areas:
    "header header header"
    "info info info";
  gap: 10px;
}

.selected-ingredients label {
  grid-area: header;
}

.ingredient {
  padding: 5px 10px;
  border: 1px solid rgba(0, 0, 0, 0.3);
  border-radius: 5px;
  background: #fafafa;
  cursor: pointer;
}

.highlighted {
  display: grid;
  gap: 2px;
  grid-area: high;
}

.input-highlighted {
  display: grid;
  grid-template-columns: repeat(2, auto);
  gap: 20px;
}

.input-highlighted label {
  display: flex;
  flex-direction: row;
  align-items: center;
  font-size: 0.8em;
  border: 1px solid black;
  background: #ffffff;
  border-radius: 5px;
  padding: 5px;
}

.input-highlighted label p {
  margin-left: 10px;
}

.photo {
  display: grid;
  gap: 2px;
  grid-area: pic;
}

.photo figure {
  position: relative;
  height: 30vh;
  min-height: 100px;
  max-height: 200px;
  overflow: hidden;
  border-radius: 10px;
}

.photo figure img {
  height: 100%;
  width: 100%;
  object-fit: cover;
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  z-index: 2;
  color: black;
  background: whitesmoke;
}

#new-pic {
  position: absolute;
  width: 100%;
  height: 100%;
  opacity: 0;
  cursor: pointer;
  padding: 20px;
}

.submit-btn {
  grid-area: btn;
  font-family: var(--heading);
  border-radius: 10px;
  padding: 10px 20px;
  background: black;
  color: white;
  margin-bottom: 20px;
}

@media only screen and (min-width: 1100px) {
  .selected-ingredients {
    grid-area: sel-ing;
    display: grid;
    grid-template-columns: repeat(5, 1fr);
    grid-template-areas:
      "header header header header header"
      "info info info info info";
  }

  .ingredients select {
    height: 120px;
  }
}
</style>