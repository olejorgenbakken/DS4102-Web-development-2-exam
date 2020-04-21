<template>
  <article class="dish card card-photo">
    <section class="photo">
      <figure class="figure">
        <input type="file" name="upload-img" id="uploaded-pic" @change="previewPic" />
        <img :src="`https:/localhost:5001/images/${photo}`" />
      </figure>
    </section>
    <section class="info">
      <section class="name">
        <label>Navn</label>
        <input v-model="name" />
      </section>
      <section class="price">
        <label>Pris</label>
        <input type="number" v-model="price" />
      </section>
      <section class="type">
        <label>Type</label>
        <select v-model="type">
          <option v-for="type in dishTypes" :value="type.name" :key="type.id">{{type.name}}</option>
        </select>
      </section>
      <section class="ingredients">
        <section class="all-ingredients">
          <label>Ingredienser</label>
          <select multiple v-model="ingredients">
            <option
              v-for="ingredient in allIngredients"
              :key="ingredient"
              :value="ingredient"
            >{{ingredient}}</option>
          </select>
        </section>
        <section class="selected-ingredients" v-if="ingredients.length > 0">
          <label>Valgte ingredienser:</label>
          <section class="list">
            <p
              class="ingredient"
              v-for="ingredient in ingredients"
              :key="ingredient"
              @click="removeIng"
            >{{ingredient}}</p>
          </section>
        </section>
      </section>
      <section class="highlighted">
        <label>Fremhevet</label>
        <section class="input-highlighted">
          <label>
            <input type="radio" v-model="highlighted" :value="true" />
            <p>Ja</p>
          </label>
          <label>
            <input type="radio" v-model="highlighted" :value="false" />
            <p>Nei</p>
          </label>
        </section>
      </section>
      <section class="desc">
        <label>Beskrivelse</label>
        <textarea v-model="description" />
      </section>
    </section>

    <section class="del">
      <button @click="deleteDish" class="del-btn">Slett</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "EditableDishItem",
  props: {
    name: String,
    id: Number,
    ingredients: Array,
    type: String,
    price: Number,
    photo: String,
    description: String,
    highlighted: Boolean
  },
  data() {
    return {
      allIngredients: [],
      dishTypes: []
    };
  },
  created() {
    let ingredientsURL = `https://localhost:5001/ingredients`;
    axios.get(ingredientsURL).then(response => {
      response.data.forEach(ingredient => {
        this.allIngredients.push(ingredient.name);
      });
    });

    let dishTypes = `https://localhost:5001/dishtypes`;
    axios.get(dishTypes).then(response => {
      this.dishTypes = response.data;
    });
  },
  methods: {
    addIngredient() {
      console.log(this.allIngredients);
    },
    deleteDish() {
      let dishesURL = `https://localhost:5001/dishes/${this.id}`;
      axios.delete(dishesURL);
    },
    previewPic() {
      let input = this.$el.querySelector("#uploaded-pic");
      this.photo = input.files[0].name;
    },
    removeIng(e) {
      this.ingredients.forEach(ingredient => {
        if (ingredient == e.target.innerText) {
          const index = this.ingredients.indexOf(ingredient);
          if (index > -1) {
            this.ingredients.splice(index, 1);
          }
          e.target.remove();
        }
      });
    }
  },
  updated() {
    this.newDish = {
      name: this.name,
      id: this.id,
      ingredients: this.ingredients,
      type: this.type,
      price: this.price,
      photo: this.photo,
      description: this.description,
      highlighted: this.highlighted
    };
    this.newDish.price = parseInt(this.newDish.price);
    this.newDish.ingredients = JSON.stringify(this.newDish.ingredients);
    let input = this.$el.querySelector("#uploaded-pic");

    let dishUploadURL = `https://localhost:5001/dishes/upload`;

    if (input.files[0] != undefined && input.files[0].name == this.photo) {
      this.newDish.photo = input.files[0].name;
    } else if (
      input.files[0] != undefined &&
      input.files[0].name != this.newDish.photo
    ) {
      let imageData = new FormData();
      imageData.append("file", input.files[0]);
      axios
        .post(dishUploadURL, imageData, {
          headers: { "Content-type": "multiplart/form-data" }
        })
        .then(() => {
          this.newDish.photo = input.files[0].name;
          let dishURL = `https://localhost:5001/dishes/`;
          axios.put(dishURL, this.newDish);
        });
    } else {
      let dishURL = `https://localhost:5001/dishes/`;
      axios.put(dishURL, this.newDish);
    }
  }
};
</script>

<style scoped>
.dish {
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 200px 1fr max-content;
  grid-template-areas:
    "pic"
    "info"
    "del";
}

section {
  display: grid;
  grid-template-columns: 1fr;
  gap: 3px;
  font-family: var(--paragraph);
}

.photo {
  grid-area: pic;
  text-align: center;
}

.figure {
  height: 100%;
  overflow: hidden;
  position: relative;
}
.figure::before {
  position: absolute;
  content: "Endre";
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  height: 100%;
  width: 100%;
  background: rgba(0, 0, 0, 0.8);
  color: white;
  opacity: 0;
  cursor: pointer;
  transition: 0.2s ease-in-out;
}

.figure:hover::before {
  opacity: 1;
}

.figure img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

input,
select,
textarea,
.input-highlighted label {
  border: 1px solid black;
  background: #ffffff;
  border-radius: 2px;
  padding: 5px;
}

input[type="text"],
select,
textarea,
.input-highlighted label {
  height: 35px;
}

textarea {
  resize: none;
}

input[type="number"] {
  width: 100%;
}

input[type="file"] {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  cursor: pointer;
  opacity: 0;
}

.info {
  grid-area: info;
  display: grid;
  grid-template-columns: 1fr;
  grid-template-areas:
    "name"
    "price"
    "type"
    "ing"
    "high"
    "desc";
  padding: 20px;
  gap: 20px;
}

.name {
  grid-template-rows: repeat(2, max-content);
  align-items: flex-start;
  grid-area: name;
}

.desc {
  grid-template-rows: max-content 1fr;
  align-items: flex-start;
  grid-area: desc;
}

.price {
  grid-template-rows: repeat(2, max-content);
  align-items: flex-start;
  grid-area: price;
}

.type {
  grid-template-rows: repeat(2, max-content);
  align-items: flex-start;
  grid-area: type;
}

.ingredients {
  grid-area: ing;
  gap: 10px;
}

.list {
  margin: -5px;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}

.all-ingredients select {
  height: 80px;
  padding: 0;
}

.selected-ingredients p {
  padding: 7px 15px;
  margin: 5px 5px;
  background: #fff;
  border: 1px solid rgba(0, 0, 0, 0.2);
  border-radius: 2px;
  cursor: pointer;
  height: max-content;
}

.highlighted {
  grid-template-rows: repeat(2, max-content);
  align-items: flex-start;
  grid-area: high;
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

.del {
  grid-area: del;
}

.del-btn {
  cursor: pointer;
  padding: 10px 20px;
  background: #ff0000;
  color: white;
}

@media only screen and (min-width: 1100px) {
  .dish {
    display: grid;
    grid-template-columns: 200px 1fr 100px;
    grid-template-rows: auto;
    grid-template-areas: "pic info del";
  }

  .info {
    grid-area: info;
    display: grid;
    grid-template-columns: 170px 1fr 300px;
    grid-template-areas:
      "name desc ing"
      "price desc ing"
      "type desc ing"
      "high desc ing";
    padding: 20px;
    gap: 20px;
  }

  .ingredients {
    grid-template-rows: 100px 1fr;
    align-items: flex-start;
  }

  textarea {
    height: 100%;
  }
}
</style>