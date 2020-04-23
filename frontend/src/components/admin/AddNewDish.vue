<template>
  <form class="new-dish card">
    <header>
      <h2>Legg til rett</h2>
    </header>
    <section class="upload">
      <section class="photo">
        <label>Bilde</label>
        <figure class="figure">
          <input type="file" name="upload-img" id="new-pic" @input="showPicture" />
          <img :src="dish.photo" alt="Last opp et bilde" />
        </figure>
      </section>
      <section class="name">
        <label>Navn</label>
        <input class="title" type="text" placeholder="Navn" autocomplete="off" v-model="dish.name" />
      </section>
      <section class="price">
        <label>Pris (kr)</label>
        <input type="number" placeholder="99" autocomplete="off" v-model="dish.price" />
      </section>
      <section class="type">
        <label>Type</label>
        <select v-model="dish.type">
          <option :value="null" selected="selected" disabled>Velg type</option>
          <option v-for="type in dishTypes" :value="type.name" :key="type.id">{{ type.name }}</option>
        </select>
      </section>
      <section class="desc">
        <label>Beskrivelse</label>
        <textarea placeholder="Beskrivelse" autocomplete="off" v-model="dish.description"></textarea>
      </section>
      <section class="highlighted">
        <label>Skal den fremheves?</label>
        <section class="input-highlighted">
          <label class="input">
            <input type="radio" v-model="dish.highlighted" :value="true" />
            <p>Ja</p>
          </label>
          <label class="input">
            <input type="radio" v-model="dish.highlighted" :value="false" />
            <p>Nei</p>
          </label>
        </section>
      </section>
      <section class="ingredients">
        <label>Ingredienser</label>
        <select multiple v-model="dish.ingredients">
          <option
            v-for="ingredient in ingredients"
            :key="ingredient"
            :value="ingredient"
          >{{ingredient}}</option>
        </select>
      </section>
      <section class="selected-ingredients" v-if="dish.ingredients.length > 0">
        <label>Valgte ingredienser:</label>
        <section class="list">
          <p class="ingredient" v-for="n in dish.ingredients" :key="n" @click="removeIng">{{n}}</p>
        </section>
      </section>
      <button @click="addNewDish" class="submit-btn">Last opp ny rett</button>
    </section>
  </form>
</template>

<script>
import axios from "axios";

export default {
  name: "AddNewDish",
  data() {
    return {
      dishTypes: [],
      ingredients: [],
      dish: {
        type: null,
        ingredients: []
      }
    };
  },
  created() {
    let ingredientsURL = `https://localhost:5001/ingredients`;
    axios.get(ingredientsURL).then(response => {
      response.data.forEach(ingredient => {
        this.ingredients.push(ingredient.name);
      });

      this.ingredient.sort((a, b) => {
        return a.localeCompare(b);
      });
    });

    let dishListURL = `https://localhost:5001/dishtypes`;
    axios.get(dishListURL).then(response => {
      this.dishTypes = response.data;
    });
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
      let dishesURL = "https://localhost:5001/dishes";
      let imageData = new FormData();
      let input = this.$el.querySelector("#new-pic");
      imageData.append("file", input.files[0]);
      this.dish.price = parseInt(this.dish.price);
      this.dish.photo = input.files[0].name;
      this.dish.ingredients = JSON.stringify(this.dish.ingredients);
      axios.post(dishesURL, this.dish).then(() => {
        axios({
          method: "post",
          url: "https://localhost:5001/dishes/upload",
          data: imageData,
          config: { headers: { "Content-type": "multiplart/form-data" } }
        }).then(() => {
          this.dish = { ingredients: [] };
        });
      });
    }
  }
};
</script>

<style scoped>
</style>