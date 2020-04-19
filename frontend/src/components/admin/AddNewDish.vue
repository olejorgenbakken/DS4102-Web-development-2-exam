<template>
  <form class="upload card">
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
    <section class="desc">
      <label>Beskrivelse</label>
      <textarea placeholder="Beskrivelse" autocomplete="off" v-model="dish.description"></textarea>
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
    <section class="type">
      <label>Type</label>
      <select v-model="dish.type">
        <option disabled hidden selected>Velg type</option>
        <option v-for="type in dishTypes" :value="type" :key="type">{{ type }}</option>
      </select>
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
      ingredientList: ["Agurk", "Chili", "Maki"],
      dish: {
        ingredients: []
      }
    };
  },
  methods: {
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
        this.dish.ingredients = JSON.parse(this.dish.ingredients);
      });
    }
  }
};
</script>

<style scoped>
.upload {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
  padding: 20px;
  font-family: var(--paragraph);
}

.upload section {
  display: grid;
}

.price,
.name,
.desc,
.type,
.highlighted,
.input-highlighted,
.photo {
  display: grid;
  gap: 3px;
}

.price input,
.name input,
.desc textarea,
.type select,
.input-highlighted label {
  border: 1px solid black;
  background: #ffffff;
  border-radius: 5px;
  padding: 5px;
}

.desc textarea {
  resize: vertical;
  min-height: 40px;
  height: 50px;
  max-height: 130px;
}

.input-highlighted {
  grid-template-columns: repeat(2, auto);
  gap: 20px;
}

.input-highlighted label {
  display: flex;
  flex-direction: row;
  align-items: center;
  font-size: 0.8em;
}

.input-highlighted label p {
  margin-left: 10px;
}

.selected-ingredients {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 10px;
}

.selected-ingredients label {
  grid-column: 1 / span 3;
}

.ingredient {
  padding: 5px 10px;
  border: 1px solid rgba(0, 0, 0, 0.3);
  border-radius: 5px;
  background: #fafafa;
}

.figure {
  position: relative;
  height: 30vh;
  min-height: 100px;
  max-height: 200px;
  overflow: hidden;
  border-radius: 10px;
}

.figure img {
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
  font-family: var(--heading);
  border-radius: 10px;
  padding: 10px 20px;
  background: black;
  color: white;
}
</style>