using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMesh : MonoBehaviour
{
   
    [Header("Parameter of JellyMesh ")]
    [SerializeField]private float intensity =1f;
    [SerializeField]private float mass =1f;
    [SerializeField]private float stiffness =1f;
    [SerializeField]private float damping =0.75f;

    //On crée 2 mesh, un qui prendra le mesh original, un qui sauvegarde l'état du mesh original
    private Mesh OriginalMesh, MeshClone;
    private MeshRenderer renderer;
    private JellyVertex[] jellyVertices;
    private Vector3[] vertexArray;


    public class JellyVertex{
        public int m_id;
        public Vector3 m_position;
        public Vector3 m_velocity, m_force;

        public JellyVertex(int p_id, Vector3 p_pos){
                m_id = p_id;
                m_position = p_pos;
        }

        public void Shake(Vector3 p_target, float p_mass, float p_stifness, float p_damping){
            m_force = (p_target - m_position) * p_stifness;
            m_velocity = (m_velocity + m_force / p_mass) * p_damping;
            m_position += m_velocity;

            if((m_velocity + m_force + m_force/ p_mass).magnitude < 0.001f){
                m_position = p_target;  
            }
                
        }
    }

    void Start()
    {
        //On attribue a l'original mesh notre mesh
        OriginalMesh = GetComponent<MeshFilter>().sharedMesh;
        //On crée un clone du mesh
        MeshClone = Instantiate(OriginalMesh);
        //On attribue au meshfilter du player le clone
        GetComponent<MeshFilter>().sharedMesh = MeshClone;
        //On sauvegarde notre renderer
        renderer = GetComponent<MeshRenderer>();

        jellyVertices = new JellyVertex[MeshClone.vertices.Length];
        for(int i = 0; i < MeshClone.vertices.Length; i++)
            jellyVertices[i] = new JellyVertex(i,transform.TransformPoint(MeshClone.vertices[i]));
    }


    void FixedUpdate()
    {
        vertexArray = OriginalMesh.vertices;
        for(int i = 0; i < jellyVertices.Length; i++ ){
            Vector3 target = transform.TransformPoint(vertexArray[jellyVertices[i].m_id]);
            float _intensity = (i - (renderer.bounds.max.y - target.y) / renderer.bounds.size.y) * intensity;
            jellyVertices[i].Shake(target, mass, stiffness, damping);
            target = transform.InverseTransformPoint(jellyVertices[i].m_position);
            vertexArray[jellyVertices[i].m_id] = Vector3.Lerp(vertexArray[jellyVertices[i].m_id], target, _intensity);
        }
        MeshClone.vertices = vertexArray;
    }
}
