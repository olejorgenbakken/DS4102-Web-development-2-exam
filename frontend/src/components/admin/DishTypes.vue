<template>
  <article class="card dish-types">
    <header>
      <h2>Kategorier</h2>
    </header>

    <section class="add">
      <label>Legg til ny type</label>
      <input type="text" v-model="newType" placeholder="Legg til ny type" />
      <button @click="addType">Legg til</button>
    </section>

    <section class="update">
      <label>Gi nytt navn</label>
      <select v-model="oldName">
        <option value="null">Velg type</option>
        <option v-for="type in dishTypes" :key="type.name">{{type.name}}</option>
      </select>
      <input type="text" v-model="newName" placeholder="Gi nytt navn" />
      <button @click="updateType">Endre</button>
    </section>

    <section class="delete">
      <label>Slett type</label>
      <select v-model="type">
        <option value="null">Slett en type</option>
        <option v-for="type in dishTypes" :key="type.name">{{type.name}}</option>
      </select>
      <button class="del-btn" @click="deleteType">Slett</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "DishTypeAdmin",
  data() {
    return {
      dishTypes: [],
      type: null,
      newType: "",
      oldName: null,
      newName: ""
    };
  },
  created() {
    let dishTypesDB = `https://localhost:5001/dishtypes`;
    axios.get(dishTypesDB).then(response => {
      let dishTypes = [];
      response.data.forEach(type => {
        dishTypes.push(type);
      });
      this.dishTypes = dishTypes;
    });
  },
  methods: {
    addType() {
      let dishTypesDB = `https://localhost:5001/dishtypes`;
      if (this.newType != "") {
        let newType = {
          name: this.newType
        };
        axios.post(dishTypesDB, newType);
      }
    },
    updateType() {
      let updatedType;
      let typeToUpdate = `https://localhost:5001/dishtypes/name/${this.oldName}`;
      axios
        .get(typeToUpdate)
        .then(response => {
          updatedType = response.data;
          updatedType.name = this.newName;
        })
        .then(() => {
          let typeToUpdate = `https://localhost:5001/dishtypes/`;
          axios.put(typeToUpdate, updatedType);
        });
    },
    deleteType() {
      let dishTypeToDelete = `https://localhost:5001/dishtypes/${this.type}`;
      axios.delete(dishTypeToDelete);
    }
  }
};
</script>

<style scoped>
.dish-types {
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