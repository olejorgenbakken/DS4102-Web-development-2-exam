<template>
  <article class="card dish-ingredients">
    <header>
      <h2>Ingredienser</h2>
    </header>

    <section class="add">
      <label>Legg til ny ingrediens</label>
      <input type="text" v-model="newIngredient" placeholder="Legg til ny ingrediens" />
      <button @click="addIngredient">Legg til</button>
    </section>

    <section class="update">
      <label>Gi nytt navn</label>
      <select v-model="oldName">
        <option value="null">Velg ingrediens</option>
        <option v-for="ingredient in allIngredient" :key="ingredient.name">{{ingredient.name}}</option>
      </select>
      <input type="text" v-model="newName" placeholder="Gi nytt navn" />
      <button @click="updateIngredient">Endre</button>
    </section>

    <section class="delete">
      <label>Slett ingrediens</label>
      <select v-model="ingredient">
        <option value="null">Slett en ingrediens</option>
        <option v-for="ingredient in allIngredient" :key="ingredient.name">{{ingredient.name}}</option>
      </select>
      <button class="del-btn" @click="deleteIngredient">Slett</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "DishIngredientAdmin",
  data() {
    return {
      allIngredient: [],
      ingredient: null,
      newIngredient: "",
      oldName: null,
      newName: ""
    };
  },
  created() {
    let allIngredientDB = `https://localhost:5001/ingredients`;
    axios.get(allIngredientDB).then(response => {
      let allIngredient = [];
      response.data.forEach(ingredient => {
        allIngredient.push(ingredient);
      });
      this.allIngredient = allIngredient;
    });
  },
  methods: {
    addIngredient() {
      let allIngredientDB = `https://localhost:5001/ingredients`;
      if (this.newIngredient != "") {
        let newIngredient = {
          name: this.newIngredient
        };
        axios.post(allIngredientDB, newIngredient);
      }
    },
    updateIngredient() {
      let updatedIngredient;
      let ingredientToUpdate = `https://localhost:5001/ingredients/name/${this.oldName}`;
      axios
        .get(ingredientToUpdate)
        .then(response => {
          updatedIngredient = response.data;
          updatedIngredient.name = this.newName;
        })
        .then(() => {
          let ingredientToUpdate = `https://localhost:5001/ingredients/`;
          axios.put(ingredientToUpdate, updatedIngredient);
        });
    },
    deleteIngredient() {
      let dishIngredientToDelete = `https://localhost:5001/ingredients/${this.ingredient}`;
      axios.delete(dishIngredientToDelete);
    }
  }
};
</script>

<style scoped>
.dish-ingredients {
  padding: 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

.delete,
.add,
.update {
  display: flex;
  flex-direction: column;
}

.delete button,
.add button,
.update button,
.update input[type="text"] {
  margin-top: 11px;
}

@media only screen and (min-width: 500px) {
  .delete button,
  .add button,
  .update button,
  .update input[type="text"] {
    margin-top: 0;
  }

  .delete,
  .add,
  .update {
    display: grid;
  }

  .delete,
  .add {
    grid-template-areas:
      "header header"
      "content content";
    grid-template-columns: 1fr 105px;
    gap: 0 20px;
  }

  .update {
    grid-template-areas:
      "header header header"
      "content content content";
    grid-template-columns: repeat(2, 1fr) 105px;
    gap: 0 20px;
  }

  .delete label,
  .update label,
  .add label {
    grid-area: header;
  }
}
</style>