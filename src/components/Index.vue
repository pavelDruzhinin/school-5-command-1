<template>
  <v-card 
  class="mx-auto" 
  max-width="500" 
  height="500">

   <v-form
    class="mx-10"
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-list-item three-line>
      <v-list-item-content>
        <div class="overline mb-4">Poll Creator</div>
        <v-list-item-title class="headline mb-1">Headline</v-list-item-title>
        <v-list-item-subtitle>Description: Lorem ipsum dolor sit amet consectetur adipisicing elit. </v-list-item-subtitle>
      
      </v-list-item-content>

      <v-list-item-avatar
        tile
        size="80"
        color="grey"
      ></v-list-item-avatar>
    </v-list-item>

    <v-text-field
      v-model="name"
      :counter="100"
      :rules="nameRules"
      label="Question"
      required
    ></v-text-field>

    <v-text-field
      v-model="email"
      :rules="emailRules"
      label="Answer"
      required
    ></v-text-field>

    
    <v-btn small fab dark color="indigo">
      <v-icon dark>mdi-plus</v-icon>
    </v-btn>

    
  </v-form>
   
  </v-card>
</template>

<script>
  
</script>